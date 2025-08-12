import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  imports: [FormsModule, CommonModule],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {
  email: string = '';
  password: string = '';
  rememberMe: boolean = false;

  onSubmit() {
    if (this.email && this.password) {
      console.log('Login attempt:', {
        email: this.email,
        password: '***',
        rememberMe: this.rememberMe
      });
      // Here you would typically call a service to authenticate
    }
  }
}
