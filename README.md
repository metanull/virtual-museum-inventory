# virtual-museum-inventory
Inventory of a Virtual-Museum. Stores, organizes and gives access to the Items in the Virtual Museum

# Development

## VirtualMuseum Controller
[/VirtualMuseum](/VirtualMuseum)

## OpenApi Documentation
[/openapi/v1.json](/openapi/v1.json)

## Swagger UI for OpenApi Documentation
[/swagger/index.html](/swagger/index.html)

# Databases

## The inventory

The `Inventory` database is the lowest layer, sustaining all others.
Its primary roles is to store the data about **Virtual Museums** (the contexts), **Partners** (the museums), the **Items** (the objects or monulentd of the partners that are displayed in the Virtual Museums) and their **Images** (different photos of the item) and **Details** (a closer look on a remarquable part of the item) 

The Inventory does NOT store any information related to the business logic of individual applications.

The objective is to provide an unique and central repository, and API to maintain, and query the Inventory; providing the required basic features to any *museum* type of application. Such application will likely rely on the inventory, but will implement their own business logic.

```mermaid
flowchart TD
    Partner("fa:fa-institution Partner") -- Participates into --> VirtualMuseum("fa:fa-book VirtualMuseum")
    Partner -- Provides --> Item("fa:fa-address-card Item")
    Item -- Has --> ItemImage("fa:fa-image ItemImage")
    Partner -. Is customized in the context of .-> ContextualizedPartner@{ label: "fa:fa-file-text Partner's Contextualized Information" }
    Item -. Is customized in the context of .-> ContextualizedItem@{ label: "fa:fa-file-text Item's Contextualized Information" }
    ItemImage -. Is customized in the context of .-> ContextualizedImage@{ label: "fa:fa-file-text Image's Contextualized Information" }
    VirtualMuseum -. Is the context for .-> ContextualizedPartner & ContextualizedItem & ContextualizedImage
    Inventory["Inventory"]

    ContextualizedPartner@{ shape: card}
    ContextualizedItem@{ shape: card}
    ContextualizedImage@{ shape: card}
    Inventory@{ shape: cyl}
     Inventory:::Aqua
    classDef Aqua stroke-width:1px, stroke-dasharray:none, stroke:#46EDC8, fill:#DEFFF8, color:#378E7A
    classDef Peach stroke-width:1px, stroke-dasharray:none, stroke:#FBB35A, fill:#FFEFDB, color:#8F632D
    style Partner fill:#FF6D00
    style VirtualMuseum fill:#FF6D00
    style Item fill:#FF6D00
    style ItemImage fill:#6DFF00
    style ContextualizedPartner fill:#BBDEFB,stroke-width:1px,stroke-dasharray: 1
    style ContextualizedItem fill:#BBDEFB,stroke-width:1px,stroke-dasharray: 1
    style ContextualizedImage fill:#BBDEFB,stroke-width:1px,stroke-dasharray: 1
```

## The collections

Different type of collections exist:
- *Museum*
- *Gallery*
- *Exhibition*
 
A **Museum**, is a Virtual Museum that presents all the *Items* and all the *Partners* defined in that Virtual Museum.

Examples: Discover Islamic Art, Discover Baroque Art, Sharing History

A **Gallery**, is a Virtual Museum that presents one collection of selected *Items*. Optionally offering a contextualized version of the items' metadata.

Examples: Carpet Art, Glass Art

An **Exhibition**, is a Virtual Museum that presents one collection of selected *Images* (Images of an Item). Optionally offering a contextualized version of the images' metadata.

Examples: The use of Colours in Art

---

In a nutshell:
- **Museum** = **All items** and all partners of the Virtual Museum
- **Gallery** = **Selected items** and partners, chosen amongst the entire inventory, and presented in one specific context
- **Exhibition** = An extension of Gallery, where the only **selected images** are presented. Such images are optionally organized in *Themes*

---

