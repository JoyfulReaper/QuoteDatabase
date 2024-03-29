import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterOutlet, Router } from '@angular/router';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, RouterLink],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'QuoteDb';

  constructor(@Inject(Router) private router: Router) {}

  search(searchTerm: string) {
    this.router.navigate(['/search', searchTerm]);
  }
}
