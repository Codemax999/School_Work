import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-venues',
  templateUrl: './venues.component.html',
  styleUrls: ['./venues.component.scss']
})
export class VenuesComponent {

  // --- Component Variables ---
  @Input() venues: Array<any>;

}
