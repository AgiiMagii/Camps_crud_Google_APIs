# Camps

A Windows Forms application built on .NET Framework, designed as a learning and experimentation project for managing camps, contracts, and related administrative workflows.

## 🧩 Architecture

The application follows a modular WinForms design using:

* A single main form with TabControl navigation
* Multiple UserControls separated by responsibility
* Shared UI actions implemented via interfaces
* Centralized control management from the main form

UI layout is structured using:

* SplitContainer
* GroupBox
* Panel

This approach reduces code duplication and improves reuse of common functionality such as action buttons.

## 🔐 Authentication & Roles

* User roles control access to different sections of the application
* Session-based user tracking ensures consistent user context across the app

## 👤 Customers Management

The `CustomersControl` handles:

* Loading and editing customer and parent data
* Asynchronous data import from Google Sheets API
* Creating and storing customers, parents, and contracts in the database

After processing, records in Google Sheets are marked as **"Processed"** to prevent duplicate handling.

## 📄 Contracts

The `ContractsControl` provides:

* Overview of all contracts
* Ability to generate and export contracts as XML

## 🏕 Camps Management

The Camps module allows:

* Creating, editing, and deleting camps
* Preventing deletion if active contracts exist
* Synchronization with Google Forms and Google Sheets via API

Each camp can display its active contracts in a dedicated tab view.

## 🪟 UI Behavior

* Dynamic tab creation for camp-specific contract views
* Tabs can be closed using an "X" button
* Navigation between active tabs is supported

## 🚧 Future Improvements

This project is actively evolving. Planned improvements include:

* Camp capacity management logic (automatic availability control)
* Payment system integration
* Code refactoring and architecture cleanup
* Logging system implementation
* Unit testing
* Improved validation and UI feedback
* Security review and enhancements

## 🎯 Purpose

This project is primarily a learning environment used to:

* Practice real-world application structure in WinForms
* Apply C#, .NET, database, and API integration skills
* Experiment with architecture, UI patterns, and business logic design

