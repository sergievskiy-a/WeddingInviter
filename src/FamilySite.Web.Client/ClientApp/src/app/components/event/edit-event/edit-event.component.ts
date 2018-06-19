import { Component, EventEmitter, Output, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Event } from '../../../models/event';
import { Location } from '../../../models/location';
import { environment } from '../../../../environments/environment.dev';

@Component({
  selector: 'app-edit-event',
  templateUrl: './edit-event.component.html',
  styleUrls: ['./edit-event.component.css']
})
export class EditEventComponent {

  @Input() event: Event;
  @Output() eventDeleted = new EventEmitter<number>();
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

  addLocation() {
    this.event.location = new Location();
  }

  removeLocation() {
    this.event.locationId = undefined;
    this.event.location = undefined;
  }

  save() {
    if (this.event.id) {
      this.http.put(environment.baseApiUrl + 'api/events', this.event, { withCredentials: true }).subscribe(response => {
        const event = response;
        this.editMode = false;
      }, error => console.error(error));
    } else {
      this.http.post(environment.baseApiUrl + 'api/events', this.event, { withCredentials: true }).subscribe(response => {
        const event = response;
        this.editMode = false;
      }, error => console.error(error));
    }
  }

  delete() {
    if (this.event.id) {
      this.http.delete(environment.baseApiUrl + 'api/events/' + this.event.id, { withCredentials: true }).subscribe(response => {
        const result = response;
        this.eventDeleted.emit(this.event.id);
      }, error => console.error(error));
    } else {
      this.event.id = -1;
      this.eventDeleted.emit(this.event.id);
    }
  }
}
