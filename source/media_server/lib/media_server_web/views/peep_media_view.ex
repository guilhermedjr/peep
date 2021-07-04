defmodule MediaServerWeb.PeepMediaView do
  use MediaServerWeb, :view
  alias MediaServerWeb.PeepMediaView

  def render("index.json", %{peep_media: peep_media}) do
    %{data: render_many(peep_media, PeepMediaView, "peep_media.json")}
  end

  def render("show.json", %{peep_media: peep_media}) do
    %{data: render_one(peep_media, PeepMediaView, "peep_media.json")}
  end

  def render("peep_media.json", %{peep_media: peep_media}) do
    %{id: peep_media.id,
      peep: peep_media.peep,
      index: peep_media.index,
      media_type: peep_media.media_type,
      media: peep_media.media}
  end
end
