import { Component, OnInit, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Tasks as TaskService } from '../../services/tasks';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-tasks',
  imports: [CommonModule, FormsModule],
  templateUrl: './tasks.html',
  styleUrls: ['./tasks.css'],
  standalone: true,
})
export class Tasks implements OnInit {
  tasks = signal<Array<Task>>([]);
  taskEdit: Task = {
    id: 0,
    title: '',
    description: '',
    isCompleted: false,
    userId: 0,
    createdAt: new Date(),
    active: true,
  };
  showTask: Task | null = null;
  addingTask = false;
  newTask: NewTask = {
    title: '',
    description: '',
  }

  constructor(private taskService: TaskService) {}

  async ngOnInit(): Promise<void> {
    const tasks: Task[] = await this.taskService.getTasks();
    this.tasks.set(tasks);
  }

  async doneTask(id: number, toggleCompleted: boolean): Promise<void> {
    await this.taskService.doneTask(id, toggleCompleted);
    const tasks: Task[] = await this.taskService.getTasks();
    this.tasks.set(tasks);
  }

  async toggleEdit(task: Task): Promise<void> {
    this.taskEdit = task;
  }

  async toggleShow(task: Task): Promise<void> {
    if (!this.showTask) this.showTask = task;
    else this.showTask = null;
  }

  async toggleAdd(): Promise<void> {
    this.addingTask = !this.addingTask;
  }

  async cancelEdit(): Promise<void> {
    this.taskEdit = {
      id: 0,
      title: '',
      description: '',
      isCompleted: false,
      userId: 0,
      createdAt: new Date(),
      active: true,
    };
  }

  async cancelAdd(): Promise<void> {
    this.newTask = {
      title: '',
      description: '',
    }
    this.addingTask = false;
  }

  async createTask(): Promise<void> {
    if (!localStorage.getItem('token')) {
      return Promise.reject('No token found');
    }
    await this.taskService.createTask(this.newTask);
    const tasks: Task[] = await this.taskService.getTasks();
    this.tasks.set(tasks);
    this.newTask = {
      title: '',
      description: '',
    }
    this.addingTask = false;
  }

  async updateTask(task: Task): Promise<void> {
    await this.taskService.updateTask(task);
    const tasks: Task[] = await this.taskService.getTasks();
    this.tasks.set(tasks);
    this.taskEdit = {
      id: 0,
      title: '',
      description: '',
      isCompleted: false,
      userId: 0,
      createdAt: new Date(),
      active: true,
    };
  }

  async deleteTask(id: number): Promise<void> {
    await this.taskService.deleteTask(id);
    const tasks: Task[] = await this.taskService.getTasks();
    this.tasks.set(tasks);
    this.showTask = null;
  }
}
