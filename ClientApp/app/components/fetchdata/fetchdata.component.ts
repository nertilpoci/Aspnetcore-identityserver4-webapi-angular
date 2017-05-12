import { Component } from '@angular/core';
import { Http, Headers, URLSearchParams } from '@angular/http';
import { OAuthService } from "angular-oauth2-oidc";

@Component({
    selector: 'fetchdata',
    templateUrl: './fetchdata.component.html'
})
export class FetchDataComponent {
    public forecasts: WeatherForecast[];

    constructor(private http: Http, private oauthService: OAuthService) {
       
    }

    fetchData() {
        let headers = new Headers();
        headers.set('Accept', 'application/json');
        headers.set('Authorization', 'Bearer ' + this.oauthService.getAccessToken());
        this.http.get('/api/SampleData/WeatherForecasts', {headers:headers}).subscribe(

            result => { this.forecasts = result.json() as WeatherForecast[]; },
            (err) => {
                if (err.status == 401) {
                    alert("You need to login");//todo redirect to login form 
                }
            }
        );
    }
}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}
