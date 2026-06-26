import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';

export interface Job {
  id: number;
  title: string;
  company: string;
  category: string;
  locationType: string; // Remote / On-site [cite: 58]
  salary: number; // [cite: 89]
  location: string; // [cite: 90]
  icon: string;
  color: string;
}

@Component({
  selector: 'app-courses',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css']
})
export class JobsComponent {
  searchQuery = '';
  selectedCategory = 'الكل';
  selectedType = 'الكل';

  categories = ['الكل', 'برمجة', 'تسويق', 'تصميم', 'محاسبة']; // [cite: 81]
  locationTypes = ['الكل', 'عن بعد', 'في الموقع']; // [cite: 58]

  allJobs: Job[] = [
    { id:1, title:'Frontend Developer', company:'R2 Tech', category:'برمجة', locationType:'عن بعد', salary:12000, location:'القاهرة', icon:'fab fa-angular', color:'purple' },
    { id:2, title:'Social Media Manager', company:'Digital Way', category:'تسويق', locationType:'في الموقع', salary:7000, location:'المنصورة', icon:'fas fa-hashtag', color:'green' },
    { id:3, title:'UI/UX Designer', company:'Creative Agency', category:'تصميم', locationType:'عن بعد', salary:9500, location:'الإسكندرية', icon:'fas fa-palette', color:'blue' }
  ];

  get filteredJobs(): Job[] {
    return this.allJobs.filter(j => {
      const matchSearch = !this.searchQuery || j.title.toLowerCase().includes(this.searchQuery.toLowerCase()) || j.company.includes(this.searchQuery);
      const matchCat = this.selectedCategory === 'الكل' || j.category === this.selectedCategory;
      const matchType = this.selectedType === 'الكل' || j.locationType === this.selectedType;
      return matchSearch && matchCat && matchType;
    });
  }
}