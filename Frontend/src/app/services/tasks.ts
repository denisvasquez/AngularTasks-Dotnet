import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Tasks {
  constructor() {}

  getTasks() {
    return [
      { id: 1, title: 'Task 1', completed: false },
      { id: 2, title: 'Task 2', completed: true },
      { id: 3, title: 'Task 3', completed: false },
    ];
  }
}
