import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import axios from 'axios';

@Injectable({
  providedIn: 'root',
})
export class Tasks {
  private api = 'https://localhost:7091/api/Tasks';
  private user = 0;

  constructor() {
    if (localStorage.getItem('token')) {
      const decodedToken: any = jwtDecode(localStorage.getItem('token')!);
      this.user = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'] || "";
    }
  }

  async getTasks() {
    if (!localStorage.getItem('token')) {
      return Promise.reject('No token found');
    }
    const response = await axios.post(this.api + '/GetTasksByUser', {
      userId: this.user,
    }, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('token')}`
      }
    });

    if (response.status === 200) {
      return response.data.tasks.reverse();
    }
  }

  async doneTask(id: number, toggleCompleted: boolean) {
    if (!localStorage.getItem('token')) {
      return Promise.reject('No token found');
    }
    const response = await axios.post(this.api + '/UpdateTask', {
      taskId: id,
      isCompleted: toggleCompleted,
    }, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('token')}`
      }
    });

    if (response.status === 200) {
      return response.data;
    }
  }

  async updateTask(task: Task) {
    if (!localStorage.getItem('token')) {
      return Promise.reject('No token found');
    }
    const response = await axios.post(this.api + '/UpdateTask', {
      taskId: task.id,
      title: task.title,
      description: task.description,
      isCompleted: task.isCompleted,
    }, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('token')}`
      }
    });

    if (response.status === 200) {
      return response.data;
    }
  }

  async createTask(task: NewTask) {
    if (!localStorage.getItem('token')) {
      return Promise.reject('No token found');
    }
    const response = await axios.post(this.api + '/CreateTask', {
      title: task.title,
      description: task.description,
      userId: this.user,
    }, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('token')}`
      }
    });

    if (response.status === 200) {
      return response.data;
    }
  }

  async deleteTask(id: number) {
    if (!localStorage.getItem('token')) {
      return Promise.reject('No token found');
    }
    const response = await axios.post(this.api + '/DeleteTask', {
      taskId: id,
    }, {
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${localStorage.getItem('token')}`
      }
    });

    if (response.status === 200) {
      return response.data;
    }
  }
}
