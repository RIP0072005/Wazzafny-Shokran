import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Job, CreateJobDto } from '../models/job';

@Injectable({
  providedIn: 'root'
})
export class JobService {
  private apiUrl = `${environment.apiUrl}/jobs`;

  constructor(private http: HttpClient) { }

  // دالة بتجيب كل الوظائف من الباك إند
  getJobs(): Observable<Job[]> {
    return this.http.get<Job[]>(this.apiUrl);
  }
  // ضيف الميثود دي جوه الـ class بتاع JobService
  getJobById(id: number): Observable<Job> {
    return this.http.get<Job>(`${this.apiUrl}/${id}`);
  }

  createJob(jobData: CreateJobDto): Observable<any> {
    return this.http.post(this.apiUrl, jobData);
  }

}