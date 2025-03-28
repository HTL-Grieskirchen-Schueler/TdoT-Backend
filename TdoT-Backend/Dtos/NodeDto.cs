﻿namespace TdoT_Backend.Dtos;
public class NodeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Story { get; set; }
    public string Width { get; set; } = string.Empty;
    public string Height { get; set; } = string.Empty;
    public List<int> Neighbors { get; set; } = [];
}
