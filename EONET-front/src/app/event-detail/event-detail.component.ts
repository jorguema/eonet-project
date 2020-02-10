import { Component, OnInit } from '@angular/core';
import { EventService } from '../services/eonet-event.service';
import { EonetEvent } from '../models/eonet-event';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.scss']
})
export class EventDetailComponent implements OnInit {
  loading: boolean = true;
  event: EonetEvent;

  constructor(
    private route: ActivatedRoute,
    private eventService: EventService
  ) { }

  ngOnInit(): void {
    this.getEvent();
  }

  getEvent(): void {
    const eventId = this.route.snapshot.paramMap.get('id').toString();
    this.eventService.getEvent(eventId)
      .subscribe(event => {
        this.event = event
        this.loading = false;
      }
      );
  }
}
