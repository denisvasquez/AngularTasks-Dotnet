import { Component, signal, OnInit } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Navigation } from "./navigation/navigation";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Navigation],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {}
