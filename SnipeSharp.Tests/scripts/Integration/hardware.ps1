using namespace System.IO

PARAM (
    [Parameter(Mandatory = $true)][ValidateNotNull()][DirectoryInfo]$Directory,
    [Parameter(Mandatory = $true)][ValidateNotNull()][StreamWriter]$ResourceStream
)
# TODO: /hardware
#           GET /bytag/{tag}
#           GET /byserial/{serial}
#           GET /audit/{audit}
#           POST /audit
#           POST /{id}/checkout
#           POST /{id}/checkin
#           GET /
#           GET /{id}
#           POST /
#           PATCH /{id}
#           DELETE /{id}
