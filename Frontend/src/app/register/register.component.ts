import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  private http = inject(HttpClient);
  private router = inject(Router);

  userRole: 'graduate' | 'employer' = 'graduate'; 
  
  // الأوبجكت اللي هنربطه بالفورم في الـ HTML
  userData = {
    name: '',
    email: '',
    password: ''
  };

  setRole(role: 'graduate' | 'employer') {
    this.userRole = role;
  }

  onSubmit() {
    // هنجمع البيانات اللي هنبعتها للباك إند
    const payload = {
      fullName: this.userData.name, // مهم جداً عشان يطابق الباك إند
      email: this.userData.email,
      password: this.userData.password,
      role: this.userRole
    };

    this.http.post<any>(`${environment.apiUrl}/users`, payload).subscribe({
      next: (response) => {
        alert('تم التسجيل بنجاح!');
        
        // دي الخطوة السحرية: هنحفظ الـ ID بتاع المستخدم في الـ localStorage
        localStorage.setItem('userId', response.id.toString());
        
        // نوجه المستخدم لصفحة الوظايف أو الـ CV
        this.router.navigate(['/jobs']); 
      },
      error: (err) => {
        console.error('خطأ في التسجيل:', err);
        alert('حدث خطأ أثناء التسجيل، تأكد من البيانات.');
      }
    });
  }
}