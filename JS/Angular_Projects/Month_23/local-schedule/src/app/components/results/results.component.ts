import { Component } from '@angular/core';

@Component({
  selector: 'app-results',
  templateUrl: './results.component.html',
  styleUrls: ['./results.component.scss']
})
export class ResultsComponent {

  // --- Component Variables ---
  displayLoading: boolean = false;

  constructor() { }

}
