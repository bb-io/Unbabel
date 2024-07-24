
# Blackbird.io Unbabel

Blackbird is the new automation backbone for the language technology industry. Blackbird provides enterprise-scale automation and orchestration with a simple no-code/low-code platform. Blackbird enables ambitious organizations to identify, vet and automate as many processes as possible. Not just localization workflows, but any business and IT process. This repository represents an application that is deployable on Blackbird and usable inside the workflow editor.

## Introduction

<!-- begin docs -->  

Unbabel is a language translation platform that combines artificial intelligence with human editing. This Unbabel application primarily centers around text/file translations and project/file management.

## Connecting

1. Navigate to apps and search for Unbabel.
2. Click _Add Connection_.
3. Name your connection for future reference e.g. 'My client'.
4. Copy your API credentials and paste it to the appropriate fields in Blackbird
5. Click _Connect_.
6. Confirm that the connection has appeared and the status is _Connected_.

## Actions

### Translations

- **Translate text** submits simple string for translation and returns the results when they are ready.
- **Translate file** submits specified file for translation and returns the results when they are ready. Service supports only txt, html and xliff file formats.

### Files

- **Upload/Download file**
- **List/Get/Delete file(s)**

### Orders

- **List orders** returns the list of all project orders.
- **Search orders** returns the list of project orders filtered by provided inputs.

### Projects

- **Search projects** returns the list of projects filtered by provided inputs.
- **Cancel project** cancels a pre-submitted project that have not been submitted.
- **Submit project** submits a project to be actioned, so that it can't be updated or canceled afterwards.
- **List/Get/Create project(s)**

## Feedback

Do you want to use this app or do you have feedback on our implementation? Reach out to us using the [established channels](https://www.blackbird.io/) or create an issue.

<!-- end docs -->
