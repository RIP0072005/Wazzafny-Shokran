import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { JobService } from '../../services/job.service';
import { HttpClient } from '@angular/common/http'; // هنحتاج ده للتقديم
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-job-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './job-details.component.html'
})
export class JobDetailsComponent implements OnInit {
  private route = inject(ActivatedRoute);
  private jobService = inject(JobService);
  private http = inject(HttpClient); // ضفنا الـ http
  job: any;

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.jobService.getJobById(id).subscribe((data: any) => {
      this.job = data;
    });
  }

  // الميثود اللي كانت مسببة الإيرور
  applyToJob() {
  const currentUserId = localStorage.getItem('userId');
  
  if (!currentUserId) {
    alert('برجاء إنشاء حساب أولاً للتقديم على الوظيفة!');
    return;
  }

  const application = {
    jobId: this.job.id,
    userId: Number(currentUserId) // هنا خدنا الـ ID الحقيقي
  };

  this.http.post(`${environment.apiUrl}/applications`, application).subscribe({
    next: () => alert('تم التقديم على الوظيفة بنجاح!'),
    error: (err) => {
      console.error(err);
      alert('حدث خطأ أثناء التقديم. ربما قدمت بالفعل!');
    }
  });
}
}