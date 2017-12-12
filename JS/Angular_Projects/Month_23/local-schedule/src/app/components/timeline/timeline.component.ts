import { Component, Input } from '@angular/core';
import { Venue } from '../../interfaces/venue';
import { Schedule } from '../../interfaces/schedule';

@Component({
  selector: 'app-timeline',
  templateUrl: './timeline.component.html',
  styleUrls: ['./timeline.component.scss']
})
export class TimelineComponent {

  // --- Component Variables ---
  @Input() venues: Array<Venue>;
  @Input() schedule: Array<Schedule>;
}
