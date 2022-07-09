namespace BoxLib.Meta
{
    [Serializable]
    struct BoxMeta
    {
        public string FieldMetaPath { get; set; }
        public string TermSegmentMetaPath { get; set; }
        public string IndexMetaPath { get; set; }
        public string IndexSegmentMetaPath { get; set; }
        public string DocSegmentMetaPath { get; set; }
    }
}