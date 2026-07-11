import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { JobService } from '../services/job.service'; // مسار السيرفيس
import { Job } from '../models/job'; // مسار الموديل

@Component({
  selector: 'app-courses',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './jobs.component.html',
  styleUrls: ['./Jobs.component.css']
})
export class JobsComponent implements OnInit {
  searchQuery = '';
  selectedCategory = 'الكل';
  selectedType = 'الكل';

  categories = ['الكل', 'برمجة', 'تسويق', 'تصميم', 'محاسبة'];
  locationTypes = ['الكل', 'عن بعد', 'في الموقع'];

  allJobs: Job[] = []; // فضيناها عشان البيانات هتيجي من الباك إند
  
  // استدعاء السيرفيس
  private jobService = inject(JobService); 

  ngOnInit(): void {
    // أول ما الصفحة تفتح، هنروح نجيب الداتا
    this.jobService.getJobs().subscribe({
      next: (data) => {
        this.allJobs = data; // نحط البيانات اللي راجعة في المتغير بتاعنا
      },
      error: (err) => {
        console.error('حصل خطأ في جلب الوظائف:', err);
      }
    });
  }

  get filteredJobs(): Job[] {
    return this.allJobs.filter(j => {
      const companyName = j.companyName || ''; // الباك إند بيبعت companyName
      
      const matchSearch = !this.searchQuery || 
                          j.title.toLowerCase().includes(this.searchQuery.toLowerCase()) || 
                          companyName.includes(this.searchQuery);
                          
      // الباك إند بيبعت الأقسام كمصفوفة categoryNames
      const matchCat = this.selectedCategory === 'الكل' || 
                       (j.categoryNames && j.categoryNames.includes(this.selectedCategory));
                       
      const matchType = this.selectedType === 'الكل' || j.locationType === this.selectedType;
      
      return matchSearch && matchCat && matchType;
    });
  }
}