import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Client, ToDoTask } from '../services/api-client';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  apiClient: Client;
  tasks$: Observable<ToDoTask[]>;
  newTask: string;

  constructor(apiClient: Client) {
    this.apiClient = apiClient;
  }

  ngOnInit() {
    this.refreshList();
  }

  refreshList() {
      this.tasks$ = this.apiClient.tasks();
  }

  addTask() {
    const task = new ToDoTask();
    task.text = this.newTask;
    this.apiClient.add(task).subscribe(response => {
      this.refreshList();
    });
  }

  deleteTask(task: ToDoTask) {
    this.apiClient.delete(task).subscribe(response => {
      this.refreshList();
    });
  }

  updateTask(checked: boolean, task: ToDoTask) {
    task.completed = checked;
    this.apiClient.update(task).subscribe(response => {
      this.refreshList();
    });
  }
}
