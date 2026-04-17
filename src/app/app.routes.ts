import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { JobsComponent } from './Jobs/Jobs.component';
import { CompaniesComponent } from './companies/companies.component'; // السطر ده لازم يتضاف
import { CvBuilderComponent } from './cv-builder/cv-builder.component';
import { RegisterComponent } from './register/register.component';
import { PostJobComponent } from './post-job/post-job.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'jobs', component:JobsComponent },
  { path: 'post-job', component: PostJobComponent },
  { path: 'companies', component: CompaniesComponent }, // المسار لصفحة الشركات
  { path: 'cv-builder', component: CvBuilderComponent },
  { path: 'register', component: RegisterComponent },
  { path: '**', redirectTo: '' } // أي مسار غلط هيرجعك للرئيسية (تأكد إن ده مش هو اللي بيحصل وقت البحث)
];