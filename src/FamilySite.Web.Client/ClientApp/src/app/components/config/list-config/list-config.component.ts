import { Component, OnInit, Inject } from '@angular/core';
import {ActivatedRoute} from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { SimpleValue } from '../../../models/simpleValue';

@Component({
  selector: 'app-list-config',
  templateUrl: './list-config.component.html',
  styleUrls: ['./list-config.component.css']
})
export class ListConfigComponent implements OnInit {

  public configValues: SimpleValue[] = [];

  constructor(private http: HttpClient, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.http.get<SimpleValue[]>('http://localhost:5000/api/config/').subscribe(result => {
      this.configValues = result;
    }, error => console.error(error));
  }
}
