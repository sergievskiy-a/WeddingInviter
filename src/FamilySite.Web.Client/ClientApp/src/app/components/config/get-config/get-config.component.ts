import { Component, Input, OnInit } from '@angular/core';
import { SimpleValue } from '../../../models/simpleValue';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-get-config',
  templateUrl: './get-config.component.html',
  styleUrls: ['./get-config.component.css']
})
export class GetConfigComponent {

  @Input() configValue: SimpleValue;

  constructor(private http: HttpClient) {
    this.configValue = new SimpleValue();
  }

}
