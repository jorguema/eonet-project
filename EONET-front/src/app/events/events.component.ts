import { Component, OnInit } from '@angular/core';
import { EonetEvent } from '../models/eonet-event';
import { EventService } from '../services/eonet-event.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit {
  events: EonetEvent[];
  loading: boolean = true;
  filter: any = {
    limit: 50,
    days: 365,
    status: 3,
    orderByProperty: 0,
    orderType: 0
  };

  constructor(private eventService: EventService) { }

  ngOnInit(): void {
    this.getEvents();
  }

  getEvents(): void {
    this.eventService.getEvents(this.filter)
      .subscribe(events => {
        this.events = events
        this.loading = false;
      }
      );
  }

  search(): void {
    if (this.filter.limit < 0) this.filter.limit = 0;
    if (this.filter.days < 0) this.filter.days = 0;
    this.loading = true;
    this.getEvents()
  }

  orderByPropertyChanged(value):void{
    if(value == 1){
      this.filter.status = 1;
    }
  }

}
