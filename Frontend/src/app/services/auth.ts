import { Injectable } from '@angular/core';
import axios from 'axios';

@Injectable({
  providedIn: 'root',
})
export class Auth {
  private api = 'https://localhost:7091/api/Users';

  constructor() {}

  async login(username: string, password: string) {
    const response = await axios.post(`${this.api}/Login`, {
      username,
      password,
    }, {
      headers: {
        'Content-Type': 'application/json',
      }
    });

    console.log(response);
    if (response.status === 200) {
      localStorage.setItem('token', response.data.message.token);
      window.location.href = '/tasks';
    }
  }

  register(usernname: string, password: string) {
    const response = axios.post(`${this.api}/Register`, {
      usernname,
      password,
    }, {
      headers: {
        'Content-Type': 'application/json',
      }
    });

    console.log(response);
  }

  async logout() {
    localStorage.removeItem('token');
    window.location.href = '/';
  }
}
