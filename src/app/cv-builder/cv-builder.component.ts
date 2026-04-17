import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // مهم جداً عشان الـ ngModel يشتغل

@Component({
  selector: 'app-cv-builder',
  standalone: true,
  imports: [CommonModule, FormsModule], // ضفنا الـ FormsModule هنا
  templateUrl: './cv-builder.component.html',
  styleUrls: ['./cv-builder.component.css']
})
export class CvBuilderComponent {
  // الأوبجكت اللي هيشيل كل بيانات الـ CV
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

  // دالة مبدئية لطباعة الـ CV أو تحويله لـ PDF
  downloadPDF() {
    window.print(); 
    // ملاحظة: دي طريقة سريعة بتفتح شاشة الطباعة وتقدر تختار منها (Save as PDF).
    // لو حابب حاجة بروفيشنال أكتر، هنستخدم مكتبة زي html2pdf.js بعدين.
  }
}