import { Component, EventEmitter, Output, Input } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Event } from '../../../models/event';

@Component({
  selector: 'app-single-event',
  templateUrl: './single-event.component.html',
  styleUrls: ['./single-event.component.css']
})
export class SingleEventComponent {

  @Input() event: Event;

  constructor(private sanitizer: DomSanitizer) {
  }
}
