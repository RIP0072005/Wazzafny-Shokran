import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Company } from '../models/company';

@Injectable({ providedIn: 'root' })
export class CompanyService {
  private http = inject(HttpClient);
  private apiUrl = `${environment.apiUrl}/companies`;

  getCompanies(): Observable<Company[]> {
    return this.http.get<Company[]>(this.apiUrl);
  }
}