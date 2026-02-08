import { Component } from '@angular/core';
import { Auth as AuthService } from '../services/auth';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-navigation',
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './navigation.html',
  styleUrl: './navigation.css',
})
export class Navigation {
  user: boolean = false;

  constructor(private auth: AuthService) {
    this.user = !!localStorage.getItem('token');
  }

  async logout(): Promise<void> {
    await this.auth.logout();
    this.user = false;
  }
}
