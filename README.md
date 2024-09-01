# miniscript

A basic, error verbose programming language that I'm working on for fun

miniscript is the product of multiple failed attempts, but I hope I won't give up on this one.

# Features

## Errors

miniscript has verbose errors, describing where it happened, what happened and sometimes how to fix it.

![image](https://github.com/user-attachments/assets/fa8a6925-3053-4cd4-9494-c3e4a0bff726)

## Feature Debug

miniscript is a modular language, meaning that custom features can be added to the interpreter easily. The features inherit from a `BaseFeature` class, creating a standardised template for features. `BaseFeature` has an overrideable function called `DebugInvoke(FeatureCallArgs args)`. This function can be overriden by the inheritor to provide useful logs to the console when the `-f_dbg` or `-feature_debug` flags are enabled.

![image](https://github.com/user-attachments/assets/1d433b0f-5b30-42df-b095-cb490a5643f2)

# Syntax

miniscript's syntax is an amalgamation of multiple different programming languages. As the language is very underdeveloped at the moment, this section wont be too in depth, but here are the basics.

## Calling Features

Features are basically just miniscript's version of built-in functions.

```
~~ Comments are annotated with double tildes.
~~ Comments arent meant to go on lines with features on, but it will probably be fine.
~~ Dont forget the space between tildes and your comment!
~~ There is also a space between the brackets and the feature name.

Feature.SubFeature ("Hello ", "World!") ("Multiple brackets!!??")

~~ Features can have multiple sets of brackets!
```

## Defining a variable

Syntax: 

```
var <name> <value>
```

Example:

```
var hello "world"
```

Variable names cannot include special characters.

```diff
- var hello! "world"
+ var hello "world"
```
