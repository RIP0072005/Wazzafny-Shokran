import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';

export interface Company {
  id: number;
  name: string;
  industry: string;
  location: string;
  openJobs: number;
  description: string;
  icon: string;
  color: string;
}

@Component({
  selector: 'app-companies',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css']
})
export class CompaniesComponent {
  companies: Company[] = [
    { id: 1, name: 'R2 Tech Solutions', industry: 'تطوير البرمجيات', location: 'القاهرة', openJobs: 5, description: 'شركة رائدة في تقديم حلول برمجية متكاملة وتطوير تطبيقات الويب والموبايل.', icon: 'fas fa-laptop-code', color: 'purple' },
    { id: 2, name: 'Creative Lab', industry: 'تصميم وجرافيك', location: 'الإسكندرية', openJobs: 2, description: 'وكالة إبداعية متخصصة في تصميم واجهات المستخدم وبناء الهوية البصرية للشركات.', icon: 'fas fa-palette', color: 'blue' },
    { id: 3, name: 'Digital Way', industry: 'التسويق الرقمي', location: 'المنصورة', openJobs: 4, description: 'نساعد العلامات التجارية على النمو من خلال استراتيجيات التسويق الرقمي وإدارة الحملات.', icon: 'fas fa-bullhorn', color: 'orange' },
    { id: 4, name: 'FinTech Hub', industry: 'التكنولوجيا المالية', location: 'القاهرة (القرية الذكية)', openJobs: 3, description: 'منصة متخصصة في حلول الدفع الإلكتروني والخدمات المالية المبتكرة.', icon: 'fas fa-chart-line', color: 'green' }
  ];
}