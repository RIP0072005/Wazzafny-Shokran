import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

// تعريف واجهة البيانات للوظيفة
export interface FeaturedJob {
  title: string;
  company: string;
  location: string;
  salary: string;
  type: string;
  icon: string;
  color: string;
}

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  // إحصائيات المنصة (Stats)
  stats = [
    { value: '+1,500', label: 'خريج تم توظيفه', icon: 'fas fa-user-graduate' },
    { value: '+350',   label: 'فرصة عمل نشطة',  icon: 'fas fa-briefcase' },
    { value: '+120',   label: 'شركة مسجلة', icon: 'fas fa-building' },
    { value: '98%',    label: 'نسبة نجاح التوظيف',  icon: 'fas fa-check-circle' }
  ];

  // تصنيفات الوظائف (Job Categories)
  categories = [
    { title: 'تطوير البرمجيات',   icon: 'fas fa-code',         color: 'purple', count: '45 وظيفة متاح' },
    { title: 'التسويق الرقمي',   icon: 'fas fa-ad',           color: 'green',  count: '30 وظيفة متاح' },
    { title: 'التصميم الإبداعي',  icon: 'fas fa-paint-brush',  color: 'blue',   count: '25 وظيفة متاح' },
    { title: 'المحاسبة والمالية', icon: 'fas fa-calculator',   color: 'orange', count: '15 وظيفة متاح' },
    { title: 'المبيعات',        icon: 'fas fa-chart-line',    color: 'purple', count: '20 وظيفة متاح' },
    { title: 'الموارد البشرية',   icon: 'fas fa-users-cog',    color: 'green',  count: '12 وظيفة متاح' }
  ];

  // أحدث الوظائف المضافة (Featured Jobs)
  featuredJobs: FeaturedJob[] = [
    { 
      title: 'Angular Developer', 
      company: 'R2 Tech Solutions', 
      location: 'القاهرة (عن بعد)', 
      salary: '12,000 - 15,000 ج.م', 
      type: 'دوام كامل', 
      icon: 'fab fa-angular', 
      color: 'purple' 
    },
    { 
      title: 'UI/UX Designer', 
      company: 'Creative Lab', 
      location: 'الإسكندرية', 
      salary: '9,000 - 11,000 ج.م', 
      type: 'عمل حر', 
      icon: 'fas fa-palette', 
      color: 'blue' 
    },
    { 
      title: 'Junior Node.js Developer', 
      company: 'Digital Way', 
      location: 'المنصورة', 
      salary: '10,000 - 13,000 ج.م', 
      type: 'دوام كامل', 
      icon: 'fab fa-node-js', 
      color: 'green' 
    }
  ];

  constructor() {}
}