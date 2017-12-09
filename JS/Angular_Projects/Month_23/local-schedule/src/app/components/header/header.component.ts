import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent {

  // --- Show / Hide Header Search Bar ---
  // if on results page
  searchBar(): boolean {
    if (window.location.pathname === '/results') return true;
    else return false;
  }
}
