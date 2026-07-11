import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-cv-builder',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './cv-builder.component.html',
  styleUrls: ['./cv-builder.component.css']
})
export class CvBuilderComponent {
  private http = inject(HttpClient);
  
  cvData = {
    fullName: '',
    jobTitle: '',
    email: '',
    phone: '',
    summary: '',
    university: '',
    graduationYear: '',
    degree: '',
    skills: ''
  };

  // حفظ البيانات في الداتابيز
  saveCv() {
    const currentUserId = localStorage.getItem('userId');
    
    if (!currentUserId) {
      alert('برجاء إنشاء حساب أولاً لحفظ السيرة الذاتية!');
      return;
    }

    // هنضيف الـ userId مع بيانات الـ CV
    const payload = {
      ...this.cvData,
      userId: Number(currentUserId) 
    };

    this.http.post(`${environment.apiUrl}/resumes`, payload).subscribe({
      next: () => alert('CV Saved Successfully!'),
      error: (err) => console.error('Error saving CV:', err)
    });
  }

  downloadPDF() {
    window.print();
  }
}