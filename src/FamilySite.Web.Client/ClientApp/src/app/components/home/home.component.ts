import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WeddingInfo } from '../../models/weddingInfo';
import { Event } from '../../models/event';
import { environment } from '../../../environments/environment';
import { CountdownService } from '../../services/countdown.service';
import { IInterval } from '../../models/Iinterval';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  public weddingInfo: WeddingInfo;
  public interval: IInterval;

  constructor(private http: HttpClient, private countdownService: CountdownService) {
    const weddingDate = 1532775600000; // timestamp of my birthday
    this.countdownService.getCountDown(weddingDate)
    .subscribe(
        i  => this.interval = i,
        error => console.log('error', error),
        () => console.log('The countdown finish'));
    }

  ngOnInit() {
    this.http.get<WeddingInfo>(environment.baseApiUrl + 'api/wedding/info').subscribe(result => {
      this.weddingInfo = result;
      this.weddingInfo.events = result.events.sort(function(a, b) {
                                  if (a.dateTime < b.dateTime) {
                                      return -1;
                                    }
                                  if (a.dateTime > b.dateTime) {
                                    return 1;
                                  }
                                  return 0;
      });    }, error => console.error(error));
  }
}
