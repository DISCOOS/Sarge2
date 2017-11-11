import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { MaterialModule } from '../../material.module';

import { LocationComponent } from '../../components/location.component';
import { UtmLocationPipe } from '../../pipes/utm-location.pipe';
import { DirectionPipe } from '../../pipes/direction.pipe';
import { DistancePipe } from '../../pipes/distance.pipe';
import { AreaPipe } from '../../pipes/area.pipe';

import { MeasureMenuComponent } from './measure-menu.component';
import { PrintMenuComponent } from './print-menu.component';
import { TracksMenuComponent } from './tracks-menu.component';
import { AreasMenuComponent } from './areas-menu.component';
import { PoiMenuComponent } from './poi-menu.component';

import { MeasureLineComponent } from './measure/measure-line.component';
import { MeasureAreaComponent } from './measure/measure-area.component';
import { MeasureTrackComponent } from './measure/measure-track.component';
import { MeasureCircleComponent } from './measure/measure-circle.component';


@NgModule({
    declarations: [
        PrintMenuComponent, 
        MeasureMenuComponent,
        TracksMenuComponent, 
        AreasMenuComponent, 
        PoiMenuComponent,
        LocationComponent,

        MeasureLineComponent,
        MeasureAreaComponent,
        MeasureTrackComponent,
        MeasureCircleComponent,

        UtmLocationPipe,
        DistancePipe,
        DirectionPipe,
        AreaPipe
    ],
    imports: [
        BrowserModule,
        FormsModule,
        MaterialModule      
    ],
    exports: [ MeasureMenuComponent, PrintMenuComponent, TracksMenuComponent, AreasMenuComponent, PoiMenuComponent, LocationComponent ]
})
export class MenuModule { };