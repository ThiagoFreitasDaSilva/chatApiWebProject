using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SignalRChatServer.Data.Entities;
[Table("connection")]
[PrimaryKey(nameof(ConnectionId))]
public class Connection {

    [Column("connection_id")]
    public string ConnectionId { get; set; }

    [Column("user_id")]
    [ForeignKey("User")]
    public int UserId { get; set; }
    public virtual User User { get; set; }

    [Column("group_name")]
    public string GroupName { get; set; }

    [Column("status")]
    public string Status { get; set; }
    
}