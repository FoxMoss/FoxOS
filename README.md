# FoxOS
a little os im working on

## Commands
`dir` show all files in that directory<br />
`wrf` write to a file<br />
`cat` read a file<br />
`rm` remove a file<br />
`basic` interpret a file as basic<br />

## BASIC
### BASIC Commands
`PRINT` print whatever follows the command<br />
`GOTO`  move curent line to whatever int follows the goto<br />
`STORE` sets the memory point to a variable<br />
`SET` sets a value to a variable<br />
`ADD` adds the following varibles like they are ints and sets the memory point to the output<br />
### BASIC Examples
#### Hello World
```
100 PRINT Hello World!
```
#### Repeat "Hello World!" forever
```
100 PRINT Hello World!
200 GOTO 100
```
#### Add 10 and 43
```
100 LET a 10
200 LET b 43
300 ADD a b
400 STORE c
500 PRINTVAR c
```
