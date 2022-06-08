using System.Text.Json.Serialization;

namespace FeatureHighlights;

public record class ResourceEvent(int ClientId, Guid ClientGuid, Guid ResourceGuid);

public record class DocumentEvent(int ClientId, Guid ClientGuid, Guid ResourceGuid, int ResourceId, int ResourceTypeId, string DocumentNumber,
    int AssignedToUserId, int AssignedFromUserId, int PreviousAssignedToUserId,
    int StatusId, string StatusName, int StatusCategoryId, int PreviousStatusCategoryId,
    bool IsDeleted, bool IsActive)
    : ResourceEvent(ClientId, ClientGuid, ResourceGuid);
