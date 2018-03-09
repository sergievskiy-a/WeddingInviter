import { Component, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Event } from '../../../models/event';
import { DateTimeFormatter } from '../../../helpers/datetime-formatter';

@Component({
  selector: 'app-edit-event',
  templateUrl: './edit-event.component.html',
  styleUrls: ['./edit-event.component.css']
})
export class EditEventComponent {

  @Input() event: Event;
  public backupEvent: Event;
  public editMode: boolean;

  constructor(private http: HttpClient) {
  }

  edit() {
    this.backupEvent = Object.assign({}, this.event);
    this.backupEvent.location = Object.assign({}, this.event.location);

    this.editMode = true;
  }

  cancel() {
    this.event = Object.assign({}, this.backupEvent);
    this.event.location = Object.assign({}, this.backupEvent.location);

    this.editMode = false;
  }

  save() {
    this.http.put('http://localhost:5000/api/events', this.event, { withCredentials: true }).subscribe(response => {
      const event = response;
      this.editMode = false;
    }, error => console.error(error));
  }

  delete() {
    this.http.delete('http://localhost:5000/api/events/', { withCredentials: true }).subscribe(response => {
      const result = response;
    }, error => console.error(error));
  }
}
