
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

- **(T) Translate text** submits a simple string for translation and returns the results when they are ready.
- **(T) Translate file** submits a file for translation and returns the translated file when they are ready. Service supports only txt, html and xliff file formats.

### Projects

- **(P) Search projects** returns the list of projects filtered by provided inputs.
- **(P) Cancel project** cancels a pre-submitted project that have not been submitted.
- **(P) Submit project** submits a project to be translated. It can't be updated or canceled afterwards.
- **(P) Create project** creates a new project. You can specify your desired pipelines here.
- **(P) Get project** get information and the current status of a project.
- **(P) Search project completed files** returns a list of all completed files. Every item will have an input file ID and an output file ID. Use the output file ID with "Downlaod file" to download the translated file.

### Files

- **(P) Upload file** upload a new file to a created profile before submitting.
- **(P) Download file** download the file ID. use in conjunction with "Search project completed files" to download completed files.

### Quality intelligence

- **(QI) Evaluate XLIFF** returns a report with quality evaluations at the word, sentence, and document level of the XLIFF file.
- **(QI) Evaluate segment** returns a report with quality evaluations at the word, sentence, and document level of the segment.
- **(QI) Explain XLIFF** returns automatic evaluation of a translation accompanied by an explanation of the XLIFF file.
- **(QI) Explain segment** returns automatic evaluation of a translation accompanied by an explanation of the segment.

## Events

- **(P) On project status changed** is triggered whenever the status of a project changes. You can additionally add the status you want to look out for to f.e. only continue a checkpoint when the project is delivered.

## Example

![1729784592233](image/README/1729784592233.png)

The above example demonstrates how Unbabel projects can be used in conjunction with checkpoints.

## Feedback

Do you want to use this app or do you have feedback on our implementation? Reach out to us using the [established channels](https://www.blackbird.io/) or create an issue.

<!-- end docs -->
