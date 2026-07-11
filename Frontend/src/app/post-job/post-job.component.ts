import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { JobService } from '../services/job.service';
import { CreateJobDto } from '../models/job'; 
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-post-job',
  standalone: true,
  imports: [CommonModule, FormsModule], 
  templateUrl: './post-job.component.html',
  styleUrl: './post-job.component.css' 
})
export class PostJobComponent implements OnInit {
  private jobService = inject(JobService);
  private http = inject(HttpClient);
  private router = inject(Router); 

  categories: any[] = []; 
  selectedCategoryId: number = 0; 

  jobObj: CreateJobDto = {
    title: '',
    description: '',
    skills: '',
    location: '',
    locationType: 'عن بعد', 
    salary: 0,
    companyId: 0, // هنخليها صفر في البداية
    categoryIds: []
  };

  ngOnInit() {
    // 1. جلب الأقسام من الباك إند
    this.http.get<any[]>(`${environment.apiUrl}/categories`).subscribe({
      next: (res) => this.categories = res,
      error: (err) => console.error('مشكلة في تحميل الأقسام:', err)
    });

    // 2. جلب الشركات عشان ناخد رقم أول شركة حقيقية موجودة في الداتابيز
    this.http.get<any[]>(`${environment.apiUrl}/companies`).subscribe({
      next: (res) => {
        if (res && res.length > 0) {
          this.jobObj.companyId = res[0].id; // هناخد رقم الشركة أوتوماتيك (سواء كان 2 أو 3 أو غيره)
        }
      },
      error: (err) => console.error('مشكلة في تحميل الشركات:', err)
    });
  }

  onSubmit() {
    if (!this.jobObj.title || !this.jobObj.description || !this.selectedCategoryId) {
      alert('يرجى إكمال جميع الحقول الأساسية واختيار التخصص!');
      return;
    }

    if (this.jobObj.companyId === 0) {
      alert('لا يوجد شركات مسجلة في النظام! يرجى إضافة شركة أولاً.');
      return;
    }

    this.jobObj.categoryIds = [Number(this.selectedCategoryId)];

    this.jobService.createJob(this.jobObj).subscribe({
      next: (res: any) => {
        alert('تم نشر الوظيفة بنجاح!');
        this.router.navigate(['/']); 
      },
      error: (err: any) => {
        console.error('حصل خطأ أثناء نشر الوظيفة:', err);
        alert('حدث خطأ! يرجى مراجعة الـ Console.');
      }
    });
  }
}