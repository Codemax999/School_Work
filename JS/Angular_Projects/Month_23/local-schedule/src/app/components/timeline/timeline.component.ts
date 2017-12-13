import { Component, Input } from '@angular/core';
import { Schedule } from '../../interfaces/schedule';

@Component({
  selector: 'app-timeline',
  templateUrl: './timeline.component.html',
  styleUrls: ['./timeline.component.scss']
})
export class TimelineComponent {

  // --- Component Variables ---
  @Input() schedule: Array<Schedule>;
}
