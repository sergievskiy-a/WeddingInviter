import { Component, OnInit } from '@angular/core';
import { SimpleValue } from '../../../models/simpleValue';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-config',
  templateUrl: './add-config.component.html',
  styleUrls: ['./add-config.component.css']
})
export class AddConfigComponent {

  public configValue: SimpleValue;

  constructor(private http: HttpClient) {
    this.configValue = new SimpleValue();
  }

  save() {
    this.http.post('http://localhost:5000/api/config', this.configValue, { withCredentials: true }).subscribe(response => {
      const result = response;
    }, error => console.error(error));
  }

}
