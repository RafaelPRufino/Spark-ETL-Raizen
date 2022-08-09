ANP Fuel Sales ETL Test
=======================

This test consists in developing an ETL pipeline to extract internal pivot caches from consolidated reports [made available](http://www.anp.gov.br/dados-estatisticos) by Brazilian government's regulatory agency for oil/fuels, *ANP (Agência Nacional do Petróleo, Gás Natural e Biocombustíveis)*.

## Goal

This `xls` file has some pivot tables like this one:

![Pivot Table](https://raw.githubusercontent.com/raizen-analytics/data-engineering-test/master/images/pivot.png)

The developed pipeline is meant to extract and structure the underlying data of two of these tables:
- Sales of oil derivative fuels by UF and product
- Sales of diesel by UF and type

The totals of the extracted data must be equal to the totals of the pivot tables.

## Execute

`git clone https://github.com/RafaelPRufino/Spark-ETL-Raizen`

`cd Spark-ETL-Raizen`

`docker-compose up --build'
