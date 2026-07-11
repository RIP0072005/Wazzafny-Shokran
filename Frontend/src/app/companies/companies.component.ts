import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { CompanyService } from '../services/company.service';
import { Company } from '../models/company';

@Component({
  selector: 'app-companies',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './companies.component.html',
  styleUrls: ['./companies.component.css']
})
export class CompaniesComponent implements OnInit {
  private companyService = inject(CompanyService);
  companies: Company[] = [];

  ngOnInit() {
    this.companyService.getCompanies().subscribe({
      next: (data) => this.companies = data,
      error: (err) => console.error('خطأ في جلب الشركات:', err)
    });
  }
}