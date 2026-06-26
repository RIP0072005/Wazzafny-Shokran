import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  userRole: 'graduate' | 'employer' = 'graduate'; // القيمة الافتراضية

  setRole(role: 'graduate' | 'employer') {
    this.userRole = role;
  }

  onSubmit() {
    console.log('Registering as:', this.userRole);
    // هنا تضيف كود الـ API الخاص بالتسجيل
  }
}