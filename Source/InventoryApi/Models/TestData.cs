namespace InventoryApi.Models;
public static class TestData {

    public static IEnumerable<VirtualMuseum> AllVirtualMuseums()
    {
        List<VirtualMuseum> VirtualMuseums = new List<VirtualMuseum>{
            new VirtualMuseum {
                Id = new Guid("00000000-0000-0000-0000-000000000000"),
                Revision = 1,
                UpdatedDate = null,
                CreatedDate = DateTime.UtcNow,
                Name = "Museum With No Frontiers",
            Description = "This is the default Virtual Museum context, it holds Items and VirtualMuseums that are not categorized yet."
            },
            new VirtualMuseum {
                Id = new Guid("701c9051-37a8-45cf-9cca-a0f6f98ecef3"),
                Revision = 1,
                UpdatedDate = null,
                CreatedDate = DateTime.UtcNow,
                Name = "Discover Islamic Art",
                Description = "Discover ISlamic Art is the first Virtual Museum ever created by Museum With No Frontiers, in 2004."
            }
        };
        return VirtualMuseums;
    }

    public static IEnumerable<Partner> AllPartners()
    {
        List<Partner> Partners = new List<Partner>{
            new Partner {
                Id = new Guid("ede4f63f-7e12-4829-a76c-a687a6f1d505"),
                Revision = 1,
                UpdatedDate = null,
                CreatedDate = DateTime.UtcNow,
                Name = "Museum With No Frontiers",
                Description = "This is the default Partner, representing the MWNF association itself; it holds Items who's rights have been transferred to MWNF by the owner."
            },
            new Partner {
                Id = new Guid("bf7e42e5-8491-4f36-90d8-c547bde4fd6f"),
                Revision = 1,
                UpdatedDate = null,
                CreatedDate = DateTime.UtcNow,
                Name = "Pascal Havelange",
                Description = "A voluntary partners that contributes with code, and not with items."
            }
        };
        return Partners;
    }

    public static IEnumerable<Item> AllItems()
    {
        List<Item> Items = new List<Item>{
            new Item {
                Id = new Guid("fea330f2-302d-4966-959f-d7663e4a4a55"),
                Revision = 1,
                UpdatedDate = null,
                CreatedDate = DateTime.UtcNow,
                PartnerId = new Guid("ede4f63f-7e12-4829-a76c-a687a6f1d505"),
                Name = "Dummy",
                Description = "This is a dummy item."
            },
            new Item {
                Id = new Guid("510dbe04-5ecd-41bb-b080-a18a3593da00"),
                Revision = 1,
                UpdatedDate = null,
                CreatedDate = DateTime.UtcNow,
                PartnerId = new Guid("ede4f63f-7e12-4829-a76c-a687a6f1d505"),
                Name = "Crash Test Dummy",
                Description = "This is another dummy item."
            }
        };
        return Items;
    }

    public static IEnumerable<Image> AllImages()
    {
        List<Image> Items = new List<Image>{
            new Image {
                Id = new Guid("1018cf65-b6c1-458a-b4fe-a1192e0aef58"),
                Revision = 1,
                UpdatedDate = null,
                CreatedDate = DateTime.UtcNow,
                ItemId = new Guid("fea330f2-302d-4966-959f-d7663e4a4a55"),
                FileId = new Guid( "00000000-0000-0000-0000-000000000000"),
                Name = "An image of a dummy",
                Description = "This is a dummy Image of a dummy."
            },
            new Image {
                Id = new Guid("cffa1944-e5a3-43d0-80ba-de419f5a1728"),
                Revision = 1,
                UpdatedDate = null,
                CreatedDate = DateTime.UtcNow,
                ItemId = new Guid("fea330f2-302d-4966-959f-d7663e4a4a55"),
                FileId = new Guid( "00000000-0000-0000-0000-000000000000"),
                Name = "Another image of the same dummy",
                Description = "This is another dummy Image of a dummy."
            },
            new Image {
                Id = new Guid("53c8b13c-7647-4b8b-a5b0-402cd20cb6cb"),
                Revision = 1,
                UpdatedDate = null,
                CreatedDate = DateTime.UtcNow,
                ItemId = new Guid("510dbe04-5ecd-41bb-b080-a18a3593da00"),
                FileId = new Guid( "00000000-0000-0000-0000-000000000000"),
                Name = "An image of another Dummy",
                Description = "This is a dummy Image of a dummy."
            },
            new Image {
                Id = new Guid("b4b4683e-3bfe-41bb-a036-f684013e56ab"),
                Revision = 1,
                UpdatedDate = null,
                CreatedDate = DateTime.UtcNow,
                ItemId = new Guid("510dbe04-5ecd-41bb-b080-a18a3593da00"),
                FileId = new Guid( "00000000-0000-0000-0000-000000000000"),
                Name = "Another image of the same another dummy",
                Description = "This is another dummy Image of a another dummy."
            }
        };
        return Items;
    }
}