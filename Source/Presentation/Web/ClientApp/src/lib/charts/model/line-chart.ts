export interface ChartDimensions
{
    width: number;
    height: number;
}

export interface LinechartAxisLabel
{
    isVisible: boolean;
    text: string;
}

export interface LinechartAxis
{
    isVisible: boolean;
    label: LinechartAxisLabel;
}

export interface LinechartColorScheme
{
    domain: string[];
}

export interface LinechartDataSet<TX, TY>
{
    name: string;
    series: LinechartDataRow<TX, TY>[];
}

export interface LinechartDataRow<TX, TY>
{
    name: TX;
    value: TY;
}

export interface LinechartConfiguration<TX, TY>
{
    dimensions: ChartDimensions;
    axisX: LinechartAxis;
    axisY: LinechartAxis;
    colorScheme: LinechartColorScheme;
    autoScale: boolean;
    showLegend: boolean;
    withGradient: boolean;
    data: LinechartDataSet<TX, TY>[];
}
