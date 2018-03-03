import {Component, Input, OnChanges, OnInit, SimpleChanges} from '@angular/core';
import {Observable} from "rxjs/Observable";
import {LinechartConfiguration} from "../../model/line-chart";

@Component({
    selector: 'awesome-linechart',
    template: `
        <ngx-charts-line-chart *ngIf="this.configuration | async; else loading; let configuration"
            [view]="[configuration.dimensions.width, configuration.dimensions.height]"
            [scheme]="configuration.colorScheme"
            [results]="configuration.data"
            [gradient]="configuration.withGradient"
            [xAxis]="configuration.axisX.isVisible"
            [yAxis]="configuration.axisY.isVisible"
            [legend]="configuration.showLegend"
            [showXAxisLabel]="configuration.axisX.label.isVisible"
            [showYAxisLabel]="configuration.axisY.label.isVisible"
            [xAxisLabel]="configuration.axisX.label.text"
            [yAxisLabel]="configuration.axisY.label.text"
            [autoScale]="configuration.autoScale"
            (select)="onSelect($event)">
        </ngx-charts-line-chart>
        <ng-template #loading>Loading...</ng-template>
    `
})

export class AwesomeLinechartComponent implements OnInit, OnChanges {
    @Input() configuration: Observable<LinechartConfiguration<Date, number>>;

    public onSelect(event: any): void { }
    public ngOnInit(): void { }
    public ngOnChanges(changes: SimpleChanges): void { }
}
