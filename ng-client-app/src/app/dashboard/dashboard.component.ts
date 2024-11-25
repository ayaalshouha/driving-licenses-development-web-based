import { Component, OnInit } from '@angular/core';
import { LoginComponent } from '../login/login.component';
import { LoginService } from '../services/login.service';
import { single } from 'rxjs';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
})
export class DashboardComponent implements OnInit {
  constructor(private loginService: LoginService, private router: Router) {}
  ngOnInit() {
    this.loginService.getLoginStatue().subscribe((loggedIn) => {
      if (!loggedIn) {
        this.router.navigate(['/login']);
      }
    });
  }
}
