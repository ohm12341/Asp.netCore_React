import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthenticationService } from './authentication.service';
import { environment } from '@environments/environment';
import { User, Vitals } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class VitalsService {
  private vitalObject: BehaviorSubject<Vitals>;

  public Vitalslist: Observable<Vitals>;

  constructor(
    private http: HttpClient,
    private authenticationService: AuthenticationService
  ) {
    this.vitalObject = new BehaviorSubject<Vitals>(
      JSON.parse(localStorage.getItem('Vitals'))
    );
    this.Vitalslist = this.vitalObject.asObservable();
  }

  public get currentUserValue(): Vitals {
    return this.vitalObject.value;
  }

  Get(): Observable<any[]> {
    let params = new HttpParams();

    // Begin assigning parameters
    params = params.append(
      'token',
      this.authenticationService.currentUserValue.token
    );

    return this.http
      .get<any>(`${environment.apiUrl}/vitals`, { params: params })
      .pipe(
        map((vitals) => {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentVitals', JSON.stringify(vitals));
          this.vitalObject.next(vitals);
          return vitals.humanVitals;
        })
      );
  }

  Save(vitals: Vitals) {
    var data = {
      organizationId: vitals.organizationId,
      businessUnitId: vitals.businessUnitId,
      deviceId: vitals.deviceId,
      heartRate: vitals.heartRate,
      temperature: vitals.temperature,
      token: this.authenticationService.currentUserValue.token,
    };
    return this.http
      .post<any>(`${environment.apiUrl}/vitals`, data, {
        headers: {
          'Content-Type': 'application/json',
          Authorization:
            'Bearer ' + this.authenticationService.currentUserValue.token,
        },
      })
      .pipe(
        map((user) => {
          // store user details and jwt token in local storage to keep user logged in between page refreshes
          localStorage.setItem('currentUser', JSON.stringify(user));

          return user;
        })
      );
  }
}
