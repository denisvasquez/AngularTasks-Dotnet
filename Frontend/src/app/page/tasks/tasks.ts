import { Component, OnInit, signal } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Tasks as TaskService } from '../../services/tasks';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-tasks',
  imports: [RouterLink, CommonModule],
  templateUrl: './tasks.html',
  styleUrl: './tasks.css',
  standalone: true,
})
export class Tasks implements OnInit {
  tasks = signal<Array<{ id: number; title: string; completed: boolean }>>([]);

  constructor(private taskService: TaskService) {}

  ngOnInit(): void {
    const tasks = this.taskService.getTasks();
    this.tasks.set(tasks);
  }
}
